# XamlX

General purpose pluggable XAML compiler with no runtime dependencies.

This is work in progress, the current goal is to reach feature parity with Portable.Xaml for the purposes of Avalonia project and add features missing in Portable.Xaml (e. g. UsableDuringInitialization) 

![default](https://user-images.githubusercontent.com/1067584/52111361-90ad7900-2614-11e9-8133-a5aa6ebb1804.png)


## Implemented features

- Direct convertion of XML to objects (instantiation, setting properties, setting attached properties)
- Support for [Content] attribute both for direct content and for collections
- Support for collections themselves (e. g. <List x:TypeArguments="sys:String"></List>
- x:Arguments Directive
- x:TypeArguments Directive
- xml:space Handling in XAML (automatically via XmlReader)

## Architecture

The flow looks like this:
 
1) Parse XAML into some basic AST (we can use different language markup parser at this point, like C#/VB in Roslyn)
2) Transform AST via visitors. At this stage types get resolved, property values get transformed either in setting properties or collection access, etc
3) Emit IL code

## Features to implement (TODO)
===============

- Support for TypeConverterAttribute and a way to provide conveters for types without one.
- A way to execute a part of markup in a deferred way (probably multiple times) for later use
- Support for intercepting property setters and BeginInit/EndInit (needed for bindings to work)
- Support for mc:Ignorable
- IsUsableDuringInitialization (assign first, set properties/contents later)
- ISupportInitialize
- Primitive types (sys:String, sys:Int32, sys:TimeSpan etc) https://docs.microsoft.com/en-us/dotnet/framework/xaml-services/built-in-types-for-common-xaml-language-primitives
- https://docs.microsoft.com/en-us/dotnet/framework/xaml-services/xaml-namespace-x-language-features
- x:FactoryMethod Directive
- x:Reference Markup Extension
- x:Array Markup Extension
- x:Key Directive 
- x:Name Directive
- x:Null Markup Extension
- x:Static Markup Extension
- x:Type Markup Extension
- {} Escape Sequence / Markup Extension
- xml:lang Handling in XAML


These directives are framework-specific and can be implemented via custom transformers/emitters
- x:Property Directive *fwspec*
- x:Uid Directive *fwspec*
- x:XData Intrinsic XAML Type *fwspec*
- x:Shared Attribute *fwspec*
- x:Class Directive *fwspec*
- x:Subclass Directive *fwspec*
- x:ClassModifier Directive *fwspec*
- x:FieldModifier Directive *fwspec*
- x:Member Directive *fwspec*
- x:Members Directive *fwspec*

Future: 
x:Code Intrinsic XAML Type (probably use Roslyn to inline C# code)
