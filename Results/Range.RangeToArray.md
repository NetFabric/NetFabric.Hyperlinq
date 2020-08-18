## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  90.59 ns | 0.275 ns | 0.244 ns |  1.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 | 100.24 ns | 0.114 ns | 0.089 ns |  1.11 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  88.75 ns | 0.219 ns | 0.194 ns |  0.98 | 0.2027 |     - |     - |     424 B |
|         LinqAF |     0 |   100 | 284.47 ns | 0.401 ns | 0.313 ns |  3.14 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 365.48 ns | 0.315 ns | 0.246 ns |  4.03 | 0.2141 |     - |     - |     448 B |
|      Hyperlinq |     0 |   100 |  95.56 ns | 0.678 ns | 0.634 ns |  1.06 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 154.62 ns | 0.297 ns | 0.278 ns |  1.71 | 0.0267 |     - |     - |      56 B |
