#include <stdexcept>
using namespace std;

extern "C" { __declspec(dllexport) int BinPow(int BaseOfPower, int power); }
extern "C" { __declspec(dllexport) int GreatestCommonDivisor(int FirstNumber, int SecondNumber); }
