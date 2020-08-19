## ValueEnumerableBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT


```
|                       Method |      Categories | Count |     Mean |    Error |   StdDev | Ratio | RatioSD | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |---------------- |------ |---------:|---------:|---------:|------:|--------:|------:|------:|------:|----------:|
|                   Enumerator |           Count | 10000 | 56.97 μs | 1.051 μs | 0.932 μs |  1.00 |    0.00 |     - |     - |     - |      24 B |
|                 MyEnumerator |           Count | 10000 | 54.75 μs | 0.542 μs | 0.507 μs |  0.96 |    0.02 |     - |     - |     - |      24 B |
|           BenValueEnumerator |           Count | 10000 | 14.10 μs | 0.099 μs | 0.092 μs |  0.25 |    0.00 |     - |     - |     - |         - |
|            MyValueEnumerator |           Count | 10000 | 14.06 μs | 0.061 μs | 0.057 μs |  0.25 |    0.00 |     - |     - |     - |         - |
|                              |                 |       |          |          |          |       |         |       |       |       |           |
|         Enumerator_Predicate | Count_Predicate | 10000 | 76.20 μs | 0.398 μs | 0.373 μs |  1.00 |    0.00 |     - |     - |     - |      24 B |
|       MyEnumerator_Predicate | Count_Predicate | 10000 | 73.32 μs | 0.636 μs | 0.595 μs |  0.96 |    0.01 |     - |     - |     - |      24 B |
| BenValueEnumerator_Predicate | Count_Predicate | 10000 | 27.56 μs | 0.260 μs | 0.231 μs |  0.36 |    0.00 |     - |     - |     - |         - |
|  MyValueEnumerator_Predicate | Count_Predicate | 10000 | 24.01 μs | 0.155 μs | 0.145 μs |  0.32 |    0.00 |     - |     - |     - |         - |
