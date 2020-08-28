# Introduction to JSON & XML

## Prerequisites

None

## Contents

1. [JSON](#json)
   - [What is JSON](#What-is-JSON)
   - [JSON Attributes](#json-attributes)
   - [JSON Structure](#json-structure)
   - [JSON Value Types](#json-value-types)
   - [JSON Objects](#json-objects)
   - [JSON Arrays](#json-arrays)
   - [JSON Exercises](#json-exercises)
2. [XML](#xml)
   - [What is XML?](#What -is-xml?)
   - [How does it work?](#how-does-it-work?)
   - [Tags & Elements](#tags-&-elements)
   - [XML Attributes](#xml-attributes)
   - [XML Exercises](#xml-exercises)
3. [XML or JSON](#xml-or-json)



## JSON 

### What is JSON?

The JSON syntax is derived from JavaScript object notation syntax, but the JSON format is text only. Code for reading and generating JSON data can be written in any programming language.

- JSON stands for JavaScript Object Notation
- JSON is a lightweight format for storing and transporting data
- JSON is often used when data is sent from a server to a web page
- JSON is "self-describing" and easy to understand
- Unlike HTML/XML focuses more on content and less on formatting 
- Used for Application Programme Interfaces 

[Back To Contents](#contents)

### JSON Attributes

- Light weight

- Language independent

- Human readable

- Easily parsed

  (NOTE: Parsed: breaking a data block into smaller chunks by following a set of rules so that it can be more easily interpreted, managed or transmitted by computer)

[Back To Contents](#contents)

### JSON Syntax

- Data is in name/value pairs
- Data is separated by commas
- Curly braces hold objects
- Square brackets hold arrays

- A name/value pair consists of a field name (in double quotes), followed by a colon, followed by a value: e.g `"firstName":"John"`

[Back To Contents](#contents)

### JSON Structure

JSON syntax format is based on two main structures; 

Objects and Arrays. 

- An **object** is a collection of name/value pairs, and 
- An **array** is an ordered list of values

[Back To Contents](#contents)

### JSON Values Types

The following is a list of values that can be presented in *JSON* data:

| **Value  type** | **Examples**                                             |
| --------------- | -------------------------------------------------------- |
| **String**      | “uk” “wales” “great britain”                             |
| **Number**      | decimal, whole, negative or  scientific notation numbers |
| **Boolean**     | true or false                                            |
| **Null**        | literal string of null                                   |
| **Object**      | {“key” : “value”} { “name”: “franca”}                    |
| **Array**       | [1,2,3] [“Red”, “Blue”,  “Green”]                        |

Note: Null is used as a default value if no value is returned.

JSON data is commonly declared using an **Object**, that has name/value pairs. However, values can be **arrays**, other **objects**, or any type as listed above.

[Back To Contents](#contents)

### JSON Objects

#### JSON: Syntax Format Rules for Objects

An Objects is a collection of name/value pairs

Starts with the left curly brackets '}' and ends with right curly brackets '}'

Each name in the Object is a string enclosed in double quotations and followed by a colon ':' then the value associated with that name `{“key” : “value”} { “name”: “franca”} `

[Back To Contents](#contents)

#### JSON: Object Declaration

A JSON object is made up of one or more *name* : *value* pairings, cuddled up within the bounds are two curly braces. A valid JSON object has the following syntax:

```json
{
 “name” : value,
 “name” : “value’’
}
```

```json
{
 “employeId”: 2983, 
 “firstName”:“Nish”, 
 “lastName”:“Mandal”, 
 “isTrainee”: true
}
```

![img](https://d2tlksottdg9m1.cloudfront.net/uploads/2019/02/basic-JSON.jpg)

[Back To Contents](#contents)

### JSON Arrays

#### JSON: syntax format rules for Arrays

1. Arrays are ordered list of values of zero-based index.
2. An arrays starts with the left bracket ‘[‘ and ends with right brackets ‘]’
3. Values are separated by comma ‘ , ‘

#### JSON: Array declaration

This array represents list of string values.

```json
{
 “trainerId”: 2403, 
 "firstName”:“joe",
“lastName”:“bloggs",
“courseStream”: [
   "SDET", "Dev-Ops", "Test", "Data"
   ]

}
```

You can group a number of objects within a square bracket 

```
{ "book": [ 
{ "isbn": 9781620645437, 
“language”: “English”,
 “edition": “third”,
 “author": “james baldwin”
 }, 
{
“isbn": 9780099499664, 
“language“: “Italian”,
“edition”: “second” ,
“author”: “mario puzo”
 } ]



 } 
```

![img](https://d2tlksottdg9m1.cloudfront.net/uploads/2019/02/JSONSample.jpg)

[Back To Contents](#contents)

#### JSON Exercises

1. Create a JSON object creating key/pairs with different types of values i.e. string, Boolean, numbers. Save with the .json extension. Use https://jsonformatter.curiousconcept.com/ to validate. Example below:

```json
{
    "Developer":"Nintendo",
    "Location":"Japan",
    "Active":"true"
}
```



2. Create a JSON object include an array 

- Create an array that is that consist of a list of strings 
- Repeat but array should be a list of objects 
- Save with the .json extension 
- Use https://jsonformatter.curiousconcept.com/ to validate



Example below:

```
{
    "Developer":"Nintendo",
    "Location":"Japan",
    "Active":"true",
    "Games Consoles":[
        {
            "Name":"NES",
            "Release Year":"1985",
            "Best Selling Game":[
                {
                    "Name":"Super Mario Bros.",
                    "Genre":"Platformer"
                }
            ]
        },
        {
            "Name":"SNES",
            "Release Year":"1991",
            "Best Selling Game":[
                {
                    "Name":"Super Mario World.",
                    "Genre":"Platformer"
                }
            ]
        },
        {
            "Name":"N64",
            "Release Year":"1996",
            "Best Selling Game":[
                {
                    "Name":"Super Mario 64.",
                    "Genre":"Platformer"
                }
            ]
        },
        {
            "Name":"GameCube",
            "Release Year":"2006",
            "Best Selling Game":[
                {
                    "Name":"Super Smash Bros. Melee",
                    "Genre":"Fighting"
                }
            ]
        },
        {
            "Name":"Wii",
            "Release Year":"2006",
            "Best Selling Game":[
                {
                    "Name":"Super Mario Bros.",
                    "Genre":"Sports"
                }
            ]
        }
    ]
}
```

[Back To Contents](#contents)

## XML 

### What is XML?

XML is a software- and hardware-independent tool for storing and transporting data:

- XML stands for eXtensible Markup Language:

  **Extensible** means that the language is a shell, or skeleton that can be extended by anyone who wants to create additional ways to use XML. 

  **Markup** means that XML’s primary task is to give definition to text and symbols. 

  **Language** means that XML is a method of presenting information that has accepted rules and formats.

- XML is a markup language much like HTML

- XML was designed to store and transport data

- XML was designed to be self-descriptive

- XML is a W3C Recommendation

**REMEMBER! XML does *nothing* - it's used to store and transport data! It is more of standard created by W3C**

**It may look similar to HTML - HTML *displays* data, XML *carries* data.**

[Back To Contents](#contents)

### How does it work?

It can be used to take data from one program convert it into XML and share it with other platforms or programs

The receiving platforms or programs can convert the XML into a format or structure that the platform uses 

Enables platforms that are very different to communicate.

[Back To Contents](#contents)

### What does it look like?

```xml
<?xml version="1.0" encoding="UTF-8" standalone="no" ?> 
<academy title = “Sparta Global Academy”> 
    <trainer1>
          <name>Nish Mandal</name>
          <stream>Engineering</stream>
          <course>C#SDET</course>
          <location>Birmingham</location>
     </trainer1>
     <trainer2> 
          <name>Cathy French</name>
          <stream>Engineering</stream>
          <course>C#DEV</course>
          <location>Birmingham</location>
    </trainer2> 
 </academy >                                     
```

The XML language has no predefined tags.

The tags in the example above (like `<name>` and `<stream>`) are not defined in any XML standard. These tags are "invented" by the author of the XML document.

HTML works with predefined tags like `<p>`, `<h1>`, `<table>`, etc.

With XML, the author must define both the tags and the document structure!

[Back To Contents](#contents)

#### XML Declaration

The XML declaration is a *processing* **instruction** that identifies the document as being XML. 

All XML documents *should*  begin with an XML declaration. Note: it has no closing tags!



```xml
<?xml
version="version_number" 
encoding="encoding_declaration" 
standalone="standalone_status" ?> 
```

- If the XML declaration is included, it must be situated at the first position of the first line in the XML document!
- If the XML declaration is included, it must contain the version number attribute
- If all of the attributes are declared in an XML declaration, they must be placed in the order shown above
- If any elements, attributes, or entities are used in the XML document that are referenced or defined in an external DTD, standalone="no" must be included
- The XML declaration must be in lower case (except for the encoding declarations)
- XML parsers are required to support UTF-8 and UTF-16 encodings (If you use anything other than the most basic English text, people may not be able to read the content you create unless you say what *character encoding* you used)

The following table shows a list of the possible attributes that may be used in the XML declaration.



| **Attribute Name:** | **Possible Attribute Value:**                                | **Attribute Description:**                                   |
| ------------------- | ------------------------------------------------------------ | ------------------------------------------------------------ |
| version             | 1.0                                                          | Specifies the version of the XML standard that the XML document conforms to. The version attribute must be included if the XML declaration is declared |
| encoding            | UTF-8, UTF-16, ISO-10646-UCS-2, ISO-10646-UCS-4, ISO-8859-1 to ISO-8859-9, ISO-2022-JP, Shift_JIS, EUC-JP | These are the encoding names of the most common character sets in use today. Defines the properties and methods for accessing and editing XML. |
| standalone          | yes, no                                                      | Use 'yes' if the XML document has an internal DTD (document type definition). Use 'no' if the XML document is linked to an external DTD, or any external entity references (i.e. If the DTD is declared inside the XML file, it must be wrapped inside the <!DOCTYPE> definition) |

Example of XML Declarations:

1.**XML declaration with no parameters** 

```xml
   <?xml>
```



**2. XML declaration with version definition** 

```xml
   <?xml version =”1.0” >
```

**3. XML declaration with all parameters defined** 

 

```xml
  <?xml version =”1.0” encoding = “UTF-8” standalone  

   = “no” ?>
```

[Back To Contents](#contents)

### Tags & Elements

**Naming Rules** 

1. Element names are case sensitive.

2. Element names must start with a letter or underscore ‘_’

3. Cannot start with xml, XML or Xml etc.

4. Element names can have characters, numbers, underscores, full stops but must **not** contain spaces or hyphens.

**General**

1.XML documents must have a root element. 

2.Elements should not overlap.

[Back To Contents](#contents)

### XML Attributes

Attributes provides additional information about the element i.e. define properties of the element

Attributes comes as a **name-value pair** separated by **equal signs** 

Attributes sit within the start tag only after the name of the element



### XML Exercises

1. Create an XML document 

2. Include at least one attribute 

3. To ensure that the XML document is well formed 

4. Open in your browser (Windows - use Ctrl O for MAC Command – O)

Use: https://www.freeformatter.com/xml-formatter.html or https://validator.w3.org/#validate_by_upload



## XML or JSON?

Both JSON and XML can be used to receive data from a web server.

**JSON Example**

```json
{"employees":[
 { "firstName":"Nish", "lastName":"Mandal" },
 { "firstName":"Lee", "lastName":"Boot" },
 { "firstName":"Cathy", "lastName":"French" }
]}
```

**XML Example**

```xml
<employees>  
  <employee>      		    
      <firstName>Nish</firstName> 
      <lastName>Mandal</lastName>  
    </employee>  
    <employee>    
      <firstName>Lee</firstName>
      <lastName>Boot</lastName>  
    </employee>  
    <employee>    
        <firstName>Cathy</firstName> 
        <lastName>French</lastName>  
    </employee>
</employees>
```

Both JSON and XML are "self describing" (human readable)

Both JSON and XML are hierarchical (values within values)

- Both JSON and XML can be parsed and used by lots of programming languages
- Both JSON and XML can be fetched with an XMLHttpRequest

**JSON is Unlike XML Because**

- JSON doesn't use end tag
- JSON is shorter
- JSON is quicker to read and write
- JSON can use arrays

XML is much more difficult to parse than JSON.
JSON is parsed into a ready-to-use JavaScript object.

[Back To Contents](#contents)