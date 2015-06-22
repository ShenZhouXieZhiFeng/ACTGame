﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class Singletone
{
    public virtual bool Initialize()
    {
        return true;
    }
    public virtual bool InitializeData()
    {
        return true;
    }
    public virtual bool Uninitialize()
    {
        return true;
    }

    public virtual bool Update()
    {
        return true;
    }
}

public class SingletonManager
{
    private GameMain m_GameMain;
    public GameMain GameMain
    {
        get { return m_GameMain; }
    }

    private Dictionary<Type, Singletone> m_dictManager = new Dictionary<Type, Singletone>();
    //private List<Singletone> m_dictManager = new List<Singletone>();

    protected SingletonManager()
    {
        //m_dictManager.Add(new CTaskManager());
        //m_dictManager.Add(new CResourceManager());
        //m_dictManager.Add(new CConfigManager());
        //m_dictManager.Add(new CUIManager());
        //m_dictManager.Add(new CModelManager());
        //m_dictManager.Add(new CCharacterManager());
        //m_dictManager.Add(new CSceneManager());
        //m_dictManager.Add(new CCameraManager());
        //m_dictManager.Add(new CInputManager());

        m_dictManager.Add(typeof(CTaskManager), new CTaskManager());

        m_dictManager.Add(typeof(CResourceManager), new CResourceManager());
        m_dictManager.Add(typeof(CConfigManager), new CConfigManager());
        m_dictManager.Add(typeof(CUIManager), new CUIManager());
        m_dictManager.Add(typeof(CModelManager), new CModelManager());
        m_dictManager.Add(typeof(CCharacterManager), new CCharacterManager());
        m_dictManager.Add(typeof(CSceneManager), new CSceneManager());
        m_dictManager.Add(typeof(CCameraManager), new CCameraManager());
        m_dictManager.Add(typeof(CInputManager), new CInputManager());
    }

    private static SingletonManager m_instance;
    public static SingletonManager Inst
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = new SingletonManager();
            }

            return m_instance;
        }
    }

    public void Initialize(GameMain main)
    {
        m_GameMain = main;
        //for (int i = 0; i < m_dictManager.Count; ++i)
        //{
        //    m_dictManager[i].Initialize();
        //}
        foreach (KeyValuePair<Type, Singletone> kvpMgr in m_dictManager)
        {
            kvpMgr.Value.Initialize();
        }
    }

    public void InitializeData()
    {
        //for (int i = 0; i < m_dictManager.Count; ++i)
        //{
        //    m_dictManager[i].InitializeData();
        //}
        foreach (KeyValuePair<Type, Singletone> kvpMgr in m_dictManager)
        {
            kvpMgr.Value.InitializeData();
        }
    }

    public void Uninitialize()
    {
        //for (int i = 0; i < m_dictManager.Count; ++i)
        //{
        //    m_dictManager[i].Uninitialize();
        //}
        foreach (KeyValuePair<Type, Singletone> kvpMgr in m_dictManager)
        {
            kvpMgr.Value.Uninitialize();
        }
    }

    public void Update()
    {
        //for (int i = 0; i < m_dictManager.Count; ++i)
        //{
        //    m_dictManager[i].Update();
        //}
        foreach (KeyValuePair<Type, Singletone> kvpMgr in m_dictManager)
        {
            kvpMgr.Value.Update();
        }
    }

    public T GetManager<T>() where T : Singletone
    {
        //if (typeof(T) == typeof(CTaskManager))
        //{
        //    return m_dictManager[0] as T;
        //}
        //else if (typeof(T) == typeof(CResourceManager))
        //{
        //    return m_dictManager[1] as T;
        //}
        //else if (typeof(T) == typeof(CConfigManager))
        //{
        //    return m_dictManager[2] as T;
        //}
        //else if (typeof(T) == typeof(CUIManager))
        //{
        //    return m_dictManager[3] as T;
        //}
        //else if (typeof(T) == typeof(CModelManager))
        //{
        //    return m_dictManager[4] as T;
        //}
        //else if (typeof(T) == typeof(CCharacterManager))
        //{
        //    return m_dictManager[5] as T;
        //}
        //else if (typeof(T) == typeof(CSceneManager))
        //{
        //    return m_dictManager[6] as T;
        //}
        //else if (typeof(T) == typeof(CCameraManager))
        //{
        //    return m_dictManager[7] as T;
        //}
        //else if (typeof(T) == typeof(CInputManager))
        //{
        //    return m_dictManager[8] as T;
        //}
        //return null;

        return m_dictManager[typeof(T)] as T;
    }
}