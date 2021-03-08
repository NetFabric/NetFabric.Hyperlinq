## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  22.75 ns | 0.173 ns | 0.154 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.28 ns | 0.026 ns | 0.024 ns |  0.58 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  12.02 ns | 0.037 ns | 0.032 ns |  0.53 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  14.86 ns | 0.037 ns | 0.033 ns |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.03 ns | 0.103 ns | 0.091 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  17.16 ns | 0.144 ns | 0.128 ns |  0.69 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  25.42 ns | 0.157 ns | 0.147 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  18.02 ns | 0.085 ns | 0.176 ns |  0.71 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  13.00 ns | 0.059 ns | 0.055 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  21.48 ns | 0.085 ns | 0.080 ns |  1.65 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 119.32 ns | 0.419 ns | 0.327 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  77.26 ns | 0.273 ns | 0.255 ns |  0.65 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  21.06 ns | 0.290 ns | 0.242 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  15.36 ns | 0.107 ns | 0.095 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  22.07 ns | 0.194 ns | 0.172 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  15.77 ns | 0.137 ns | 0.122 ns |  0.71 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  12.92 ns | 0.077 ns | 0.068 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  21.38 ns | 0.158 ns | 0.140 ns |  1.65 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 114.65 ns | 0.549 ns | 0.487 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  75.89 ns | 0.439 ns | 0.389 ns |  0.66 | 0.0191 |     - |     - |      40 B |
