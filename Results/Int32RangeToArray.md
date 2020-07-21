## Int32RangeToArray

### Source
[Int32RangeToArray.cs](../LinqBenchmarks/Int32/Range/Int32RangeToArray.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|         Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|        ForLoop |     0 |   100 |  84.32 ns | 0.501 ns | 0.468 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           Linq |     0 |   100 |  85.38 ns | 1.092 ns | 1.021 ns |  1.01 |    0.01 | 0.2218 |     - |     - |     464 B |
|     LinqFaster |     0 |   100 |  80.15 ns | 0.805 ns | 0.714 ns |  0.95 |    0.01 | 0.2027 |     - |     - |     424 B |
|     StructLinq |     0 |   100 | 330.38 ns | 2.066 ns | 1.933 ns |  3.92 |    0.03 | 0.7801 |     - |     - |    1632 B |
|      Hyperlinq |     0 |   100 |  81.42 ns | 0.546 ns | 0.456 ns |  0.97 |    0.01 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Pool |     0 |   100 | 119.73 ns | 0.688 ns | 0.643 ns |  1.42 |    0.01 | 0.0267 |     - |     - |      56 B |
