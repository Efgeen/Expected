# Expected

A minimalistic abstraction of Andrei Alexandrescu's "Expect the expected" for C#.

## Using(s)

### Single-project scope
* Add the ``SExpected.cs`` file directly to an existing project. (For project-wide usage.)

### Multi-project scope
1. Add the ``SExpected.cs`` file to any project.
2. Add a reference to the project containing the ``SExpected.cs`` file.
3. Add usings, e.g.,
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
