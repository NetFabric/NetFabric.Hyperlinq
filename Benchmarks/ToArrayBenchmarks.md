## ToArrayBenchmarks

### Source
[ToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ToArrayBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    54.51 ns |  0.700 ns |  0.620 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|                    StructLinq_Array |                     Array |   100 |   237.49 ns |  2.046 ns |  1.914 ns |  4.36 |    0.07 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |    34.78 ns |  0.681 ns |  0.637 ns |  0.64 |    0.01 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |    29.85 ns |  0.229 ns |  0.203 ns |  0.55 |    0.01 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |    33.18 ns |  0.270 ns |  0.226 ns |  0.61 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   920.41 ns |  4.586 ns |  4.065 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   952.07 ns |  6.714 ns |  6.280 ns |  1.04 |    0.01 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   549.15 ns |  5.730 ns |  5.080 ns |  0.60 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    46.82 ns |  0.859 ns |  0.804 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   949.15 ns |  3.461 ns |  2.702 ns | 20.31 |    0.36 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    61.75 ns |  0.540 ns |  0.505 ns |  1.32 |    0.03 | 0.2180 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    49.11 ns |  0.471 ns |  0.441 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|               StructLinq_List_Value |                List_Value |   100 |   956.68 ns |  5.561 ns |  5.202 ns | 19.48 |    0.19 | 0.2174 |     - |     - |     456 B |
|                Hyperlinq_List_Value |                List_Value |   100 |    46.58 ns |  0.733 ns |  0.650 ns |  0.95 |    0.02 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   709.85 ns |  4.236 ns |  3.755 ns |  1.00 |    0.00 | 0.5655 |     - |     - |    1184 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   725.41 ns |  4.189 ns |  3.270 ns |  1.02 |    0.01 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   838.52 ns |  5.988 ns |  5.308 ns |  1.18 |    0.01 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    46.98 ns |  0.794 ns |  0.743 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   724.19 ns |  6.340 ns |  5.930 ns | 15.42 |    0.26 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    55.05 ns |  0.788 ns |  0.698 ns |  1.17 |    0.02 | 0.2142 |     - |     - |     448 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    49.02 ns |  0.553 ns |  0.518 ns |  1.00 |    0.00 | 0.2027 |     - |     - |     424 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   763.81 ns |  4.313 ns |  3.823 ns | 15.58 |    0.22 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    47.37 ns |  0.363 ns |  0.339 ns |  0.97 |    0.01 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,715.28 ns | 18.518 ns | 14.458 ns |     ? |       ? | 0.5836 |     - |     - |    1224 B |
|                                     |                           |       |             |           |           |       |         |        |       |       |           |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,382.86 ns | 17.070 ns | 15.132 ns |     ? |       ? | 0.5951 |     - |     - |    1248 B |
