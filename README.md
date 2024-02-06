# Expected

## Usings
```cs
global using EXPECTED_H;
global using static EXPECTED_H.SExpected;
```
## Usage
```cs
private static SExpected<float, string> Divide(float numerator, float denominator) {
  if (denominator == 0.0f) {
    return "division by zero";
  }
  return numerator/denominator;
}
private static void Main(void) {
  SExpected<float, string> quotient = Divide(1.0f, 1.0f);
  if (quotient.HasValue) {
    /* quotient.Value */
  }
  else {
    /* quotient.Error */
  }
}
```
