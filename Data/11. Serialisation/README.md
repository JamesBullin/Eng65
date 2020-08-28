# Serialisation

## Prerequisites

1. Complete "File Types, Encoding & Streaming" lesson

## Introduction to Serialisation

Serialisation** is the process of converting an object into a stream of bytes to store the object *or* transmit it to memory, a database, or a file

Could be in binary or text form

Its main purpose is to save the state of an object in order to be able to recreate it when needed

The reverse process is called **deserialization**

We can serialise objects to

- Binary
- XML
- JSON

**Streaming** means sending data (whether a serialised object, or any other information) from our application to another location.

![](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/media/index/serialization-process.gif)



- Walkthrough the `Serialisation` solution and look at the 3 projects. One covers Binary Serialisation, another covers JSON serialisation, and the other XML Serialisation

## Why serialise and when would you know what to serialise to?

- You want to be able permanently store your data
- One way of doing it is a database
- But you might want to send it over a network
- Advantage over network using text (JSON or XML) nobody needs to know structure of program, they’re self describing (name field etc)
- You can easily change XML file or serialise some XML and change it and read it in.
- Binary is more secure, but if you’re serialising objects, the serialised objects only work within objects with same class (e.g. persons class, can’t open up in Python).
- Public things such as web message tend to be JSON or XML
- Games are set up using Binary

## Note

Serializes and deserializes an object, or an entire graph of connected objects, in binary format

`BinaryFormatter` implements the `IFormatter` interface

Example of polymorphism as in c#, an interface cannot be instantiated directly, but it can be instantiated by a class or struct that implements an interface.

Following is the example of creating an instance for the interface IFormatter:

`IFormatter formatter = new BinaryFormatter();`

In c#, a class can inherit only from one class but we can implement a multiple interfaces in a class or struct by using interfaces.

## Further Reading

- Serialisation (C#) https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/serialization/
- Serialization in .NET: https://docs.microsoft.com/en-us/dotnet/standard/serialization/
- Serialisation with Newtonsoft: https://www.newtonsoft.com/json/help/html/Introduction.htm
- XMLDocument class https://docs.microsoft.com/en-us/dotnet/api/system.xml.xmldocument?view=netcore-3.1