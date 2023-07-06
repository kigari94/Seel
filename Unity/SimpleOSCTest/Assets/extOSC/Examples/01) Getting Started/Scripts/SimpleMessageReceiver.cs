﻿/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;

namespace extOSC.Examples
{
    public class SimpleMessageReceiver : MonoBehaviour
    {
        #region Public Vars

        public string Address = "/example/1";

        [Header("OSC Settings")]
        public OSCReceiver Receiver;

        #endregion

        #region Unity Methods

        protected virtual void Start()
        {
            Receiver.Bind(Address, ReceivedMessage);
        }

        #endregion

        #region Private Methods

        private void ReceivedMessage(OSCMessage message)
        {
            Debug.LogFormat("Received: {0}", message);
			Debug.Log(float.Parse(message.Values[0].StringValue));
            transform.position = new Vector3(1, transform.position.y, transform.position.z);
        }

        #endregion
    }
}