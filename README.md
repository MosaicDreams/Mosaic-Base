# Mosaic Base

Small different pieces of code as a base for Mosaic Toolset.
> Note: DOTween and [Tween Actions](https://github.com/ErfanNikouie/Tween-Actions) are included here.

---

## Introduction

In the production process of Mosaic Toolset, we needed to have some functionality that was necessary for us to achieve what we wanted. So we developed a collection of functionalities that helped us to implement The Mosaic Toolset. There are 7 tools and we will explain each one of them.

---

## Table of Contents

- Editor Tools
- Enum Generation
- Extentions
- Pages
  - Page Parent
  - Page Element
- [Pairs](#5-pairs)
- Tween Actions
- [Waiter](#7-waiter)

---

## 5. [Pairs](#table-of-contents)

### Description

Sometimes we want to hold two different types in one. So we created a Pair class to do this for us. The **Pair<TFirst, TSecond>** class offers a robust and adaptable solution for managing pairs of values in **C#**. This class enables you to efficiently store, manipulate, and compare two potentially distinct data types within a single encapsulated entity. It is an invaluable tool, especially when your programming tasks involve handling pairs of values within your applications.

---

### Syntax

So when we want to use this class we will define it first via :

```C#
using Mosaic.Base.Pairs;
```

Then we can use it in our code. Here is a simple example :

```C#
Pair<int, string> pair = new Pair<int, string>(42, "Hello");
int firstValue = pair.First;      // Retrieves the first element (42)
string secondValue = pair.Second; // Retrieves the second element ("Hello")

```

---

### Methods

We designed some methods to simply *store, manipulate, and compare* the two value that is given to the constructor. There are currently 6 methods that we can work with.

1. **WithFirst(TFirst newFirst):**

    - This method allows you to create a new Pair object with the first element replaced by a specified value, while keeping the second element unchanged. It provides a means to update the contents of the pair without altering the other element.

    ```C#
    Pair<int, string> pair = new Pair<int, string>(42, "Hello");
    Pair<int, string> updatedPair = pair.WithFirst(123); // Now it should be (123, "Hello") in the updatedPair
    ```

2. **WithSecond(TSecond newSecond):**

    - Similar to the WithFirst method, WithSecond permits you to generate a new Pair instance with the second element substituted by a given value, leaving the first element unaltered. This is a convenient way to modify one element while preserving the other.

    ```C#
    Pair<int, string> pair = new Pair<int, string>(42, "Hello");
    Pair<int, string> updatedPair = pair.WithSecond("World"); // New pair with the second element updated to "World"
    ```

3. **Equals(Pair<First, Second> other):**

    - This method facilitates the comparison of the current Pair instance with another Pair object for equality. It assesses whether both the first and second elements of the pairs match.

    ```C#
    Pair<int, string> pair1 = new Pair<int, string>(42, "Hello");
    Pair<int, string> pair2 = new Pair<int, string>(42, "Hello");
    bool areEqual = pair1.Equals(pair2); // Returns true since both pairs have the same elements
    ```

    - There is an overridden implementation of the Equals method that accepts an object as its parameter. It enables type-specific equality comparison and ensures compatibility with standard equality comparisons.

4. **GetHashCode():**

    - This method generates a unique hash code for the Pair object based on the values of its elements. It is useful for various data structures and algorithms that rely on hash codes for efficient storage and retrieval.

5. **IsNull():**

    - The IsNull method checks if both elements within the Pair object are null. It returns true if both the first and second elements are null.

6. **HasNull():**

    - The HasNull method determines if at least one of the elements within the Pair object is null. It returns true if either the first or second element is null.

---

## 7. [Waiter](#table-of-contents)

### Description

The Waiter class is a versatile utility tailored for utilization within the Unity game engine. It greatly streamlines the orchestration of time-sensitive operations, including timed delays and delayed actions. An important feature of this class is its adherence to the Singleton pattern, ensuring that a sole instance exists within the application, rendering it an indispensable and structured asset for a diverse range of game development scenarios.

### Syntax 

When we want to use this class in unity, we need to include that in our code :

```C#
using Mosaic.Base.Waiter
```

Then we can work with it. We provided a simple example but we will explain them in detail.

```C#
// Basic waiting using the Wait method
Waiter.Instance.Wait(2.0f, () => { Debug.Log("Waited for 2 seconds!"); });

// Creating a unique Waiter instance and waiting with it
Waiter customWaiter = Waiter.GetUniqueInstance("CustomWaiter", true);
customWaiter.Wait(3.5f, () => { Debug.Log("Custom Waiter: Waited for 3.5 seconds!"); });
```

### Methods

In Waiter you should know three important things.

1. **GetUniqueInstance Method :**

    - `GetUniqueInstance(string name, bool dontDestroyOnLoad = true)` : This method allows you to create a unique instance of the Waiter class with a specified name.

    - Parameters:

        - `name` : A string that defines the name of the unique Waiter instance.

        - `dontDestroyOnLoad(optional, default is true)` : A boolean flag that determines whether the unique instance should persist across scene changes. If set to true, the instance remains active during scene transitions.

```C#
// Create a custom Waiter instance and make it persistent across scene changes
Waiter customWaiter = Waiter.GetUniqueInstance("CustomWaiter", true);
customWaiter.Wait(3.5f, () => { Debug.Log("Custom Waiter: Waited for 3.5 seconds!"); });
```

2. **Wait Method :**

    - `Wait(float seconds, System.Action callback)` : This method starts a coroutine that waits for a specified duration in seconds and then invokes the provided callback function.

    - Parameters:

        - `seconds` : The duration in seconds to wait before executing the callback.

        - `callback` : The action to be executed after the specified waiting period.

```C#
// Basic waiting using the Wait method
Waiter.Instance.Wait(2.0f, () => { Debug.Log("Waited for 2 seconds!"); });
```

3. **InstanceWait Method :**

    - `InstanceWait(float seconds, System.Action callback)` : A static method that uses the Singleton instance of the Waiter class to initiate a waiting coroutine.

    - Parameters:

        - `seconds` : The duration in seconds to wait before executing the callback.

        - `callback` : The action to be executed after the specified waiting period.

```C#
// Use the Singleton instance to start a waiting coroutine
Waiter.InstanceWait(2.5f, () => { Debug.Log("Using Singleton instance: Waited for 2.5 seconds!"); });
```
