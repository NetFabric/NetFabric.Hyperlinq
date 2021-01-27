## List.Int32.ListInt32Select

### Source
[ListInt32Select.cs](../LinqBenchmarks/List/Int32/ListInt32Select.cs)

### References:
- Cistern.ValueLinq: [0.0.11](https://www.nuget.org/packages/Cistern.ValueLinq/0.0.11)
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.19.2](https://www.nuget.org/packages/StructLinq.BCL/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta27](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta27)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.200-preview.20614.14
  [Host]        : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                      Method | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     ForLoop |   100 | 136.62 ns | 0.194 ns | 0.162 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                 ForeachLoop |   100 | 243.94 ns | 1.046 ns | 0.927 ns |  1.79 |    0.01 |      - |     - |     - |         - |
|                        Linq |   100 | 830.25 ns | 2.788 ns | 2.471 ns |  6.08 |    0.02 | 0.0343 |     - |     - |      72 B |
|                  LinqFaster |   100 | 419.30 ns | 2.928 ns | 2.739 ns |  3.07 |    0.02 | 0.2179 |     - |     - |     456 B |
|                      LinqAF |   100 | 767.76 ns | 1.219 ns | 1.080 ns |  5.62 |    0.01 |      - |     - |     - |         - |
|                  StructLinq |   100 | 236.85 ns | 0.297 ns | 0.248 ns |  1.73 |    0.00 | 0.0191 |     - |     - |      40 B |
|        StructLinq_IFunction |   100 | 166.23 ns | 0.525 ns | 0.465 ns |  1.22 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_Foreach |   100 | 168.21 ns | 0.420 ns | 0.393 ns |  1.23 |    0.00 |      - |     - |     - |         - |
| Hyperlinq_Foreach_IFunction |   100 | 160.16 ns | 0.458 ns | 0.428 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_For |   100 | 214.47 ns | 0.839 ns | 0.744 ns |  1.57 |    0.01 |      - |     - |     - |         - |
|     Hyperlinq_For_IFunction |   100 |  89.00 ns | 0.249 ns | 0.233 ns |  0.65 |    0.00 |      - |     - |     - |         - |
