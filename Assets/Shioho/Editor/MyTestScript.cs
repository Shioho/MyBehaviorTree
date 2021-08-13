using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Shioho;
using System;

namespace Tests
{
    public class MyTestScript
    {
        // A Test behaves as an ordinary method
        //[Test]
        //public void PropertyIntTest()
        //{
        //    var value = new Property<int>(10);

        //    Assert.IsTrue(value.Equals(10));
        //}

        //[Test]
        //public void PropertyStringTest()
        //{
        //    var value = new Property<string>("aaaaa");

        //    Assert.IsTrue(value.Equals("aaaaa"));
        //}

        [Test]
        public void PropertyObjectTest()
        {
            var value = new Property<TestObj>(new TestObj(1, 2));

            Assert.IsTrue(value.Equals(new TestObj(1, 3)));
        }



    }
    public class TestObj 
    {
        public int a;
        public int b;
        List<int> list;

        public TestObj(int a, int b)
        {
            this.a = a;
            this.b = b;
            list = new List<int>();
            list.Add(a);
            list.Add(b);

        }
    }
}
