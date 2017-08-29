# Reorderable List

An attempt to mimic the ReorderableList within Unity while adding some extended functionality.

![](http://imgur.com/XcDQniZ.png)

## Features

* Drag and Drop references (like array inspector)
* Expandable items and list itself
* Multiple selection (ctrl/command, shift select)
* Draggable selection
* Context menu items (revert values, duplicate values, delete values)
* Custom attribute which allows automatic list generation for properties*
* Event delegates and custom styling

## Usage

There are 2 ways to use the ReorderableList
1. Create a custom Editor for your class and create a ReorderableList pointing to your serializedProperty
2. Create custom list class which extends from ReorderableArray<T>, assign [Reorderable] attribute above property (not class).
