package main

import "fmt"

// Greeting формирует приветствие для переданного имени.
func Greeting(name string) string {
	return fmt.Sprintf("Hello, %s!", name)
}

// SumRange складывает все числа от from до to включительно.
func SumRange(from, to int) int {
	sum := 0
	for i := from; i <= to; i++ {
		sum += i
	}
	return sum
}
