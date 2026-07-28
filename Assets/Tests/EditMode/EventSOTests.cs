using System;
using NUnit.Framework;
using Runtime.Codes.Scripts.EventSO;
using UnityEngine;

namespace Tests.Tests.EditMode
{
    public class EventSOTests
    {
        [Test]
        public void VoidEventSO_Invoke_CallsEvent()
        {
            var soEvent = ScriptableObject.CreateInstance<VoidEventSO>();
            var isCalled = false;
            soEvent.OnEvent += () => isCalled = true;
            soEvent.Invoke();
            Assert.IsTrue(isCalled);
        }

        [Test]
        public void IntEventSO_Invoke_CallsEvent()
        {
            var soEvent = ScriptableObject.CreateInstance<IntEventSO>();
            var testValue = 67;
            soEvent.OnEvent += (value) => testValue = value;
            soEvent.Invoke(42);
            Assert.IsTrue(testValue == 42);
        }

        [Test]
        public void VoidEventSO_Remove_CallsEvent()
        {
            var soEvent = ScriptableObject.CreateInstance<VoidEventSO>();
            var isCalled = false;
            var call = new Action(() => isCalled = true);
            soEvent.OnEvent += call;
            soEvent.OnEvent -= call;
            soEvent.Invoke();
            Assert.IsFalse(isCalled);
        }

        [Test]
        public void IntEventSO_Remove_CallsEvent()
        {
            var soEvent = ScriptableObject.CreateInstance<IntEventSO>();
            var testValue = 67;
            var call = new Action<int>((value) => testValue = value);
            soEvent.OnEvent += call;
            soEvent.OnEvent -= call;
            soEvent.Invoke(42);
            Assert.IsFalse(testValue == 42);
        }
    }
}