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
- [Pairs](#7-pairs)
- Tween Actions
- Waiter

---

## 7. [Pairs](#table-of-contents)

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
