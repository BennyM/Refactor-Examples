# Refactoring

This repository is my starting point to illustrate several refactorings. 

The naming of the examples mentioned below is based upon the book: [Refactoring](https://martinfowler.com/books/refactoring.html) by [Martin Fowler](https://twitter.com/martinfowler). An [online catalog](https://refactoring.com/catalog/) is also available. Another very good reference is [Working Effectively with Legacy Code](https://www.r7krecon.com/legacy-code) by [Michael Feathers](https://twitter.com/mfeathers).

## Conditionals

### Decompose
Extract methods from the condition, then and else part.

### Consolidate 
Combine conditions with the same result.

### Guard Clauses
Conditinal behaviour can make the path unclear.

### Strategy
Use a strategy to decide the outcome.

### Replace with Polymorphism
Different behaviour based on an identifier (int, enum, type). Encapsulate in class.

## Method calls

### Seperate query from modifier
Create two methods, one for the query and one for the modification.

### Null Objects
Replace null value with null object