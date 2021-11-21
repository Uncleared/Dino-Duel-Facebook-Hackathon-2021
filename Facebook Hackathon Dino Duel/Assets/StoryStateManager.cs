//using DG.Tweening;i
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public abstract class StoryState
//{
//    public StoryStateManager stateManager;
//    public virtual void Start(StoryStateManager stateManager)
//    {
//        this.stateManager = stateManager;
//    }

//    // this is so that each state handles its own responses
//    public abstract void HandleResponse(string intent);
//}

//public class IsAnyoneThere : StoryState
//{
//    public override void HandleResponse(string intent)
//    {
//        if(intent == "noticeGirl" || intent == "greeting")
//        {
//            stateManager.ChangeState(stateManager.IsAnyoneThere2);
//        }
//    }

//    public override void Start(StoryStateManager stateManager)
//    {
//        base.Start(stateManager);
 
//        stateManager.girl.SayDialogue("Is anyone there?");
//    }
//}

//// "I think I hear a voice.. is someone really there?
//public class IsAnyoneThere2 : StoryState
//{
//    public override void HandleResponse(string intent)
//    {
//        if (intent == "noticeGirl" || intent == "greeting")
//        {
//            stateManager.ChangeState(stateManager.WhatIsAroundMe);
//        }
//    }

//    public override void Start(StoryStateManager stateManager)
//    {
//        base.Start(stateManager);

//        stateManager.girl.SayDialogue("Is there a voice?");
//    }
//}

//// Is there anything around me?
//public class WhatIsAroundMe : StoryState
//{
//    public override void HandleResponse(string intent)
//    {
//        if (intent == "noticeGirl" || intent == "greeting")
//        {

//        }
//    }

//    public override void Start(StoryStateManager stateManager)
//    {
//        base.Start(stateManager);
//        Transform tree = stateManager.sceneObjects.tree;

//        tree.transform.DOMove(tree.position + new Vector3(0, 5.35f, 0), 0.3f);

//        stateManager.girl.SayDialogue("Is there anything around me?");
//    }
//}


//public class StoryStateManager : MonoBehaviour
//{
//    public SceneObjectReferencer sceneObjects;
//    public Girl girl;
//    public IsAnyoneThere IsAnyoneThere = new IsAnyoneThere();
//    public IsAnyoneThere2 IsAnyoneThere2 = new IsAnyoneThere2();
//    public WhatIsAroundMe WhatIsAroundMe = new WhatIsAroundMe();
//    public StoryState currentState;

//    public void ReceiveResponse(string intent)
//    {
//        print($"Received {intent}");
//        currentState.HandleResponse(intent);
//    }
//    public void ChangeState(StoryState newState)
//    {
//        this.currentState = newState;
//        this.currentState.Start(this);
//    }
//    // Start is called before the first frame update
//    void Start()
//    {
//        ChangeState(IsAnyoneThere);
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
