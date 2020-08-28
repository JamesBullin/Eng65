# File Types, Encoding & Streaming



## Prerequisites

1. Complete "XML and JSON" lesson

## Contents

1. [Text vs Binary files](#Text-vs-Binary-files)
2. [File Signatures](#File-Signatures)
3. [Encoding](# Encoding)
   - [Binary Encoding](#Binary-Encoding)
   - [Character-Based encoding](#Character-Based-encoding)
4. [Streaming](#Streaming)
   - [Synchronous vs asynchronous](#Synchronous-vs-asynchronous)
   - [Stream readers & writers](#Stream-readers-&-writers)
   - [using & IDisposable](#using-&-IDisposable)
   - [Buffering streams](#Buffering-streams)
5. [Further Reading](#further-reading)

## Text vs Binary Files

All files are stored as a sequence of `bytes`(1001 0011) – binary files

Text files (.txt) are interpreted as sequences of characters (text) with newlines

Rich text files (.doc) will also have additional information (colour, font…) which the program handling them needs to interpret

Other binary files have different interpretations:

- Specified by their file format (.jpg, .zip, .dll, exe)
- Not human readable

[Back to contents](#contents)

## File Signatures

Every file starts with a few bytes which identify the file type - these are called the **file signature**.

For example JPG files always start with `FF D8` (hex) which looks like `1111111111011000` in binary

This many be followed by header information describing the contents of the file

We can see a list of file signatures here: https://en.wikipedia.org/wiki/List_of_file_signatures

## Encoding

Encoding is the act of using a common language for storing and reading files

In this way different operating systems and applications are able to read and write the same data

There are two main types of encoding:

- Binary
- Character-based

### Binary Encoding

- The advantage of binary files is that they are very fast, and when we send and receive data there is no data conversion to perform, so the data transfer is able to operate at the limits of the hardware and software transfer mechanism.

- Binary files generally can only be opened by the applications which are specifically designed to read them.
- `.bin` also is a binary file, which you may see sometimes.

#### Exercise

Open command prompt 

 Type in “`Powershell`”

 Navigate to C:\Windows\System32

 Type in Format-Hex mspaint.exe

```powershell
4d5a 9000 0300 0000 0400 0000 ffff 0000
b800 0000 0000 0000 4000 0000 0000 0000
0000 0000 0000 0000 0000 0000 0000 0000
0000 0000 0000 0000 0000 0000 e800 0000
0e1f ba0e 00b4 09cd 21b8 014c cd21 5468
6973 2070 726f 6772 616d 2063 616e 6e6f
7420 6265 2072 756e 2069 6e20 444f 5320
6d6f 6465 2e0d 0d0a 2400 0000 0000 0000
c9e0 c68a 8d81 a8d9 8d81 a8d9 8d81 a8d9
84f9 3bd9 bd81 a8d9 e2e5 abd8 8e81 a8d9
e2e5 acd8 9681 a8d9 e2e5 add8 bd81 a8d9
e2e5 a9d8 9081 a8d9 8d81 a9d9 6f85 a8d9
```

Should see something like this.

 This is a binary file!

[Back to contents](#contents)

### Character based Encoding

#### ASCII Encoding

The most common type of computer encoding is ascii encoding.

What this uses is the numbers from 0 through to 127 to represent certain computer characters like escape and space and others, and all of the simple letters and numbers a to z, A to Z and 0 to 9 and symbols like !"£$%^&*(* etc

![ASCII](https://upload.wikimedia.org/wikipedia/commons/1/1b/ASCII-Table-wide.svg)

#### UTF-8 Encoding

Data is often put into blocks of 8 called bytes. 8 `bits` of 1 or 0 = 1 `byte`  10101010

All characters in ASCII can be encoded using UTF-8 without an increase in storage (both requires a byte of storage). UTF-8 has the added benefit of character support beyond "ASCII-characters". If that's the case, why will we *ever* choose ASCII encoding over UTF-8?

UTF-8 takes our basic ASCII encoding so that it fits neatly in blocks of 8 bits

- 1010101  ASCII (7 bits)
- 01010101  UTF-8 (8 bits) notice the leading zero

#### UTF-16 Encoding

The only problem with ASCII and UTF-8 is that the characters represented are only the basic English characters

They represent what we call American English which was used to create the first computers, and this has stuck throughout all of computing today, even throughout the whole world.

However to cater for all languages of the world, for example Chinese Mandarin or Japanese or other cultures who use various symbols for their letters, we have created UTF-16 which takes 2 bytes (16 bits) of data for every character

#### Exercise

Run the code below:

```c#
char s = 'h';
Console.WriteLine(System.Convert.ToInt32(s));
```

.NET stores all strings as a sequence of UTF-16 code units. (This is close enough to "Unicode characters" for most purposes.)

Fortunately for you, Unicode was designed such that ASCII values map to the same number in Unicode, so after you've converted each character to an integer, you can just check whether it's in the ASCII range. Note that you can use an implicit conversion from char to int - there's no need to call a conversion method.

Write a `foreach` loop which converts each character into the `ASCII code` is represents

 Use `Console.ReadLine()` as the string variable:

```c#
string s = Console.ReadLine();
foreach( char c in s)
{
  Console.WriteLine(System.Convert.ToInt32(c));
}
```

https://en.wikipedia.org/wiki/List_of_file_signatures

https://www.nayuki.io/page/what-are-binary-and-text-files

[Back to contents](#contents)

## Streaming

When dealing with large files we can use a technique called **streaming** to deal with this.

**Streaming** means sending data from one location to another

For example, from our C# application to/from:

- A file on the local computer
- To local computer memory
- to a http:// address
- to an https:// address
- to another port eg ssh

A **stream** is an abstraction of a sequence of bytes: 

- It is a very narrow stream
- One end puts bytes into the stream, the other end takes them out

`System.IO.Stream` is the abstract base class for a sequence of bytes

![](https://www.tutorialsteacher.com/Content/images/csharp/stream-heirarchy.png)

Derived classes include:

- `System.IO.BufferedStream`
- `System.IO.FileStream`
- `System.IO.MemoryStream`
- `System.IO.Pipes.PipeStream`
- `System.Net.Security.AuthenticationStream`
- `System.Printing.PrintQueueStream`

Defines properties such as `CanRead`, `CanWrite`, `Length`, `Position`, `ReadTimeout`….

And methods such as `Read`, `Write`, `Flush`, `Seek`, `Dispose`

Note all the common functionality – a stream is a stream no matter where it starts and where it is going

[Back to contents](#contents)

### Synchronous vs asynchronous

C# supports both synchronous and asynchronous methods. **Synchronous** basically means that you can only execute one thing at a time. **Asynchronous** means that you can execute multiple things at a time and you don't have to finish executing the current thing in order to move on to next one:

![asyncvssync](https://miro.medium.com/max/734/1*Y41dOkntUbR3I4UCJBx9Xg.png)*



Synchronous operation

- Call the method – eg `Read`, `Write`, `CopyTo`, `Flush`
- Wait for it to finish (return)
- Carry on execution

Asynchronous operation

- Call the method – eg `ReadAsync`, `WriteAsynch`, `CopyToAsync`, `FlushAsync`
- Carry on execution (With instructions on what do when the operation finishes)
- The program doesn't block waiting for the operation
- Useful for UI – still responsive

### Stream readers & writers

- Earlier in the course we looked at static `System.IO.File` methods for reading and writing text from / to a file
- For example `File.WriteAllText("Hello.txt", text);`
- These methods are simple to use - Open the named file and write the specified string to it
- Creating a stream, wrapping it in a writer, doing the read operation, closing the stream and handling any exceptions are done for you. You can specify the encoding – default is UTF-8:

`File.WriteAllText("Hello.txt", text, new UnicodeEncoding());`

- The `System.IO` namespace also provides types for reading encoded characters from streams and writing them to streams
- Typically, streams are designed for byte input and output
- The reader and writer types handle the conversion of the encoded characters to and from bytes so the stream can complete the operation. Each reader and writer class is associated with a stream, which can be retrieved through the class's Base Stream property.
- When streaming data we should cleanly close the file handle when done. The easiest way to do this is to enclose the streaming data object within a using statement

**Recap – writing and reading a single string to/from a text file**

```c#
string path1 = Directory.GetCurrentDirectory();

var path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\location\"));
//write text
string text = "In a champagne supernove in the sky";
File.WriteAllText(@$"{path2}ChampagneSupernova.txt", text);

string path1 = Directory.GetCurrentDirectory();
var path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\location\"));
string text = "In a champagne supernova in the sky";
File.WriteAllText(@$"{path2}ChampagneSupernova.txt", text);

//WriteAllText(string, string[]). Create a new file which write an array as lines
string[] lyrics = { "So", "Sally", "Can", "Wait" };
File.WriteAllLines($@"{path2}DontLookBackInAnger.txt", lyrics);
//read all text
string lyrics2 = File.ReadAllText(@$"{path2}ChampagneSupernova.txt");
Console.WriteLine(lyrics);
```

- For more customisation, the `System.IO` namespace also provides types for reading and writing from streams
- Each reader and writer class is associated with a stream, which can be retrieved through the class's Base Stream property.
- Typically, streams are designed for byte input and output. The reader and writer types handle the conversion of the encoded characters to and from bytes so the stream can complete the operation. 



```c#
using System;
using System.IO;
using System.Text;

namespace Encoding_Streaming
{
	class Program
	{
		static void Main(string[] args)
		{
			string path1 = Directory.GetCurrentDirectory();
			var path2 = Path.GetFullPath(Path.Combine(path1, @"..\..\..\location\"));
			//the file is being opened in append mode – if the file already exists, the specified text is appended to the end. If it doesn't already exist, the file is created.The stream associated with the StreamWriter has a file as its endpoint.Notice that with this method we can read and process the file line by line until the end of the file is reached

			using (StreamWriter sw = File.AppendText(@$"{path2}Champagne-Supernova"))
			{
				sw.WriteLine("In a Champagne Supernove in the skyyyy");
			}


			using (StreamReader sr = File.OpenText(@$"{path2}Champagne-Supernova"))
	
			{
				//The variable ‘s’ will be used to read all the data from the file
				string s = "";
				//We then use the stream reader method ReadLine to read each line from the stream buffer
				while ((s = sr.ReadLine()) != null)
				{
					//As a result, each line will be transferred from the file to the buffer, then the 			
					//string line will be transferred from the buffer to the variable ‘s’
					Console.WriteLine(s);
				}


			}
		}
	}

}
```

[Back to contents](#contents)

### `using` & `IDisposable`

- When streaming data we should cleanly close the handle to the stream when done. 
- The easiest way to do this is to enclose the streaming data object within a using statement
- The `Dispose()` method is called automatically when the `StreamWriter` goes out of scope, because StreamWriter implements the `IDisposable` interface
- `Dispose()` safely closes the stream if it still exists and is open 

```
using (StreamWriter sw = File.AppendText(@$"{path2}Champagne-Supernova"))
{
	sw.WriteLine("In a Champagne Supernove in the skyyyy");
}
```
### Buffering Streams

You can added a buffered layer on to a stream

A buffer is a byte cache in memory@

- Read or write when the buffer is full
- Rather than one byte at a time as data arrives
- Improves performance (faster)

```c#
using (Stream ns= new NetworkStream(clientSocket, true), 

bufStream = new BufferedStream(ns, 1024))

{ /* do something */  }`
```

First construct the stream,then construct the buffered stream with it. Specify the buffer size

[Back to contents](#contents)

## Further Reading:

1. File and steam I/O in .NET 

   https://docs.microsoft.com/en-us/dotnet/standard/io/ 

2. File signatures https://en.wikipedia.org/wiki/List_of_file_signatures

3. ASCII Character table https://commons.wikimedia.org/wiki/File:Ascii-proper-color.svg

4. UTF-16 Encoding  https://upload.wikimedia.org/wikipedia/commons/0/01/Unifont_Full_Map.png 

   http://www.unicode.org/charts/

5. System.IO.Stream https://docs.microsoft.com/en-us/dotnet/api/system.io.stream?view=netcore-3.1

6. TextReader and TextWriter https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader?view=netcore-3.1

7. Text Encoding in .NET https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.1

8. Asynchronous streams: https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/generate-consume-asynchronous-stream