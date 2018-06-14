# Reorderable List

An attempt to mimic the ReorderableList within Unity while adding some extended functionality.

![](https://raw.githubusercontent.com/cfoulston/Unity-Reorderable-List/master/Screenshots/screenshot.jpg)

## Features

* Drag and Drop references (like array inspector)
* Expandable items and list itself
* Multiple selection (ctrl/command, shift select)
* Draggable selection
* Context menu items (revert values, duplicate values, delete values)
* Custom attribute which allows automatic list generation for properties*
* Event delegates and custom styling
* Pagination
* Sorting (sort based on field, ascending and descending)
___

## Usage

There are two ways to use the ReorderableList
1. Create a custom Editor for your class and create a ReorderableList pointing to your serializedProperty
2. Create custom list class which extends from ReorderableArray<T>, assign [Reorderable] attribute above property (not class).
___

## Pagination

Pagination can be enabled in two ways:

1. With the [Reorderable] attribute:
	* `[Reorderable(paginate = true, pageSize = 0)]`
2. Properties of the ReorderableList:
	* `list.paginate`
	* `list.pageSize`

`pageSize` defines the desired elements per page. Setting `pageSize = 0` will enable the custom page size GUI

When enabled, the ReorderableList GUI will display a small section below the header to facilitate navigating the pages

![](https://raw.githubusercontent.com/cfoulston/Unity-Reorderable-List/master/Screenshots/pagination.jpg)

#### NOTE 
*Elements can be moved between pages by right-clicking and selecting "Move Array Element"*