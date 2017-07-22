using NUnit.Framework;
using JordiBisbal.Bag;

public class BagTest {

    [Test]
    public void testHasNotHadItem() {
        Bag<object> bag = new Bag<object>();
        Assert.False(bag.Has("NotHadItem"));
    }

    [Test]
    public void testHasHadItem() {
        Bag<object> bag = new Bag<object>();
        bag.Add("HadItem", "WhatEver");
        Assert.True(bag.Has("HadItem"));
    }

    [Test]
    public void testAddAndGet() {
        Bag<object> bag = new Bag<object>();
        bag.Add("Item", "ItemValue");
        Assert.AreEqual("ItemValue", bag.Get("Item"));
    }

    [Test]
    public void testGetDifferentValue() {
        Bag<object> bag = new Bag<object>();
        bag.Add("Item", "ItemValue");
        bag.Add("Item 2", "ItemValue 2");
        Assert.AreEqual("ItemValue", bag.Get("Item"));
        Assert.AreEqual("ItemValue 2", bag.Get("Item 2"));
    }

    [Test]
    public void testReplaceValue() {
        Bag<object> bag = new Bag<object>();
        bag.Add("Item", "ItemValue");
        bag.Add("Item 2", "ItemValue 2");
        Assert.AreEqual(bag.Get("Item"), "ItemValue");
        bag.Replace("Item", "AnotherItemValue");
        Assert.AreEqual("AnotherItemValue", bag.Get("Item"));
    }

    [Test]
    public void testRemovingValue() {
        Bag<object> bag = new Bag<object>();
        bag.Add("Item", "ItemValue");
        bag.Add("Item 2", "ItemValue 2");
        bag.Remove("Item");
        Assert.True(bag.Has("Item 2"));
        Assert.False(bag.Has("Item"));
    }

    [Test]
    public void testRemovingUnexistentValueThrowsException() {
        ItemNotFoundException exception = Assert.Throws<ItemNotFoundException>(delegate () {
            Bag<object> bag = new Bag<object>("myBag");
            bag.Add("Item 2", "ItemValue 2");
            bag.Remove("NoItem");
        });
        Assert.AreEqual("Item \"NoItem\" not found in \"myBag\" bag", exception.Message);
    }

    [Test]
    public void testRemovingUnexistentValueThrowsExceptionOnUnnamedBag() {
        ItemNotFoundException exception = Assert.Throws<ItemNotFoundException>(delegate () {
            Bag<object> bag = new Bag<object>();
            bag.Add("Item 2", "ItemValue 2");
            bag.Remove("NoItem");
        });
        Assert.AreEqual("Item \"NoItem\" not found in \"unnamed\" bag", exception.Message);
    }

    [Test]
    public void testAlreadyExistentValue() {
        ItemAlreadyExistsException exception = Assert.Throws<ItemAlreadyExistsException>(delegate () {
            Bag<object> bag = new Bag<object>();
            bag.Add("Existent Item", "ItemValue 1");
            bag.Add("Existent Item", "ItemValue 2");
        });
        Assert.AreEqual("Item \"Existent Item\" already exists in \"unnamed\" bag", exception.Message);
    }

    [Test]
    public void testGetDefaultValueForInexistentValue() {
        Bag<object> bag = new Bag<object>();
        Assert.AreEqual("DefaultValue", bag.Get("Item", "DefaultValue"));
    }

    [Test]
    public void testGetValueForExistentValueNotDefault() {
        Bag<object> bag = new Bag<object>();
        bag.Add("Item", "OwnValue");
        Assert.AreEqual("OwnValue", bag.Get("Item", "DefaultValue"));
    }
}
