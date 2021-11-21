//using Facebook.WitAi;
//using Facebook.WitAi.CallbackHandlers;
//using Facebook.WitAi.Lib;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class StoryIntentHandler : WitResponseHandler
//{
//    public StoryStateManager stateManager;
//    public float minConfidence = 0.7f;
//    protected override void OnHandleResponse(WitResponseNode response)
//    {
//        var intentNode = WitResultUtilities.GetFirstIntent(response);
//        string intent = intentNode["name"].Value;
//        float confidence = intentNode["confidence"].AsFloat;
//        if (confidence > minConfidence)
//        {
//            stateManager.ReceiveResponse(intent);
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
