﻿/* Copyright (c) 2020 ExT (V.Sigalkin) */

using UnityEngine;
using System;
using System.Globalization;

namespace extOSC.Examples
{
    public class SimpleMessageReceiver : MonoBehaviour
    {
        #region Public Vars

        public string Address = "/example/1";
        public float offset = 0.0f;

        [Header("OSC Settings")]
        public OSCReceiver Receiver;
        private Vector3 initPos;

        #endregion

        #region Unity Methods

        protected virtual void Start()
        {
            Receiver.Bind(Address, ReceivedMessage);
            initPos = transform.position;
        }

        #endregion

        #region Private Methods

        private void ReceivedMessage(OSCMessage message)
        {
            //Debug.LogFormat("Received: {0}", message);
            string valueString = message.Values[0].StringValue;
            float value = (float) Convert.ToDouble(valueString, CultureInfo.GetCultureInfo("en-US")) + offset;
			Debug.Log(value);
            if(value != 0.0f)
            {
                transform.position = initPos + new Vector3((value * 10), 0, 0);
                Debug.Log("Result: " + transform.position);
            }
        }

        #endregion
    }
}