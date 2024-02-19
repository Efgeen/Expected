# Expected

## Usings
```cs
global using EXPECTED_H;
global using static EXPECTED_H.SExpected;
```
## Usage
```cs
private static SExpected<float, string> Divide(float n, float d) {
    if (d == 0.0f) {
        return "division by zero";
    }
    return n/d;
}
private static void Main(void) {
    SExpected<float, string> q;
    q = Divide(1.0f, 1.0f);
    if (q.HasValue) {
        _ = q.Value;
    }
    else {
        _ = q.Error;
    }
}
```
