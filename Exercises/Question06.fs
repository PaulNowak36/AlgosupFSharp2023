namespace FSharpKoans
open FSharpExercises.Core
open NUnit.Framework

type Item = {
    Product: string;
    Price: float;
}

type Discount =
    | None
    | RoundDown
    | Percent of float

type Store = {
    Name: string;
    Discount: Discount;
    Inventory: Item list;
}

module StoreInventories =
    let item (name, price) = { Product = name; Price = price; }


    let bookStore() = { Name = "Bookstore"; Discount = None; Inventory = [item("Fiction", 20); item("Non-Fiction", 25)] }
    let clothingStore() = { Name = "Clothing Store"; Discount = Percent 0.2; Inventory = [item("Shirt", 30); item("Pants", 40)] }
    let foodStore() = { Name = "Grocery Store"; Discount = RoundDown ; Inventory = [item("Apple", 1.5); item("Banana", 2.3)] }

    let storeList() = [bookStore(); clothingStore(); foodStore()]

module Question06 =

    // "Shopping list"

    // You have a list of shopping to buy.
    // There are three different stores that may sell the item
    // * Bookstore
    // * Clothing Store
    // * Grocery Store
    //
    // You have a list of items to buy, along with a quantity. The items could come from any store.
    // You can assume the items exist in one store and only one store. The stores may or may not
    // give a discount.
    //
    // The stores discounts are the following:
    // * Bookstore - never gives a discount
    // * Clothing Store - always gives a twenty percent discount
    // * Grocery Store - always rounds the price down i.e. items costing 1.9 or 1.1 would always be charged at 1.0
    //
    // A model of the stores and discount schemes is provided
    //
    // Use the provided model to calculate how much you would spend on a shopping list


    let calcCost (storeList: Store list) (itemList: list<string * int>) : float =
         __


    [<Test>]
    let ``Question 06 - Test Case 01``() =
        let itemList = ["Non-Fiction", 2;]
        let actualValue = calcCost (StoreInventories.storeList()) itemList
        let expectedValue = 50.0

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 06 - Test Case 02``() =
        let itemList = ["Apple", 3; "Banana", 1;]
        let actualValue = calcCost (StoreInventories.storeList()) itemList
        let expectedValue = 6.0

        AssertEquality expectedValue actualValue

    [<Test>]
    let ``Question 06 - Test Case 03``() =
        let itemList = ["Apple", 5; "Pants", 1;]
        let actualValue = calcCost (StoreInventories.storeList()) itemList
        let expectedValue = 39.0

        AssertEquality expectedValue actualValue


