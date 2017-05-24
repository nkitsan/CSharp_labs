// SomeFunctions.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "algorithm"
#include "SomeFunctionsDll.h"

int BinPow(int BaseOfPower, int power)
{
	int result = 1;
	while (power) 
	{
		if (power & 1)
			result *= BaseOfPower;
		BaseOfPower *= BaseOfPower;
		power >>= 1;
	}
	return result;
}

 int GreatestCommonDivisor(int FirstNumber, int SecondNumber)
 {
	 while (SecondNumber) {
		 FirstNumber %= SecondNumber;
		 int Temporary = FirstNumber;
		 FirstNumber = SecondNumber;
		 SecondNumber = Temporary;
	 }
	 return FirstNumber;
 }