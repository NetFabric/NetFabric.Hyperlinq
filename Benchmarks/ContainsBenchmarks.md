## ContainsBenchmarks

### Source
[ContainsBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    33.95 ns | 0.159 ns | 0.149 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    31.35 ns | 0.184 ns | 0.153 ns |  0.92 |    0.01 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    75.10 ns | 0.389 ns | 0.364 ns |  2.21 |    0.01 |      - |     - |     - |         - |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    24.75 ns | 0.063 ns | 0.056 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    81.33 ns | 0.599 ns | 0.500 ns |  2.40 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   659.38 ns | 2.814 ns | 2.494 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   767.96 ns | 3.133 ns | 2.616 ns |  1.17 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |    34.06 ns | 0.220 ns | 0.206 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    35.94 ns | 0.214 ns | 0.189 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |    34.82 ns | 0.186 ns | 0.174 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |    36.75 ns | 0.158 ns | 0.148 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,076.46 ns | 5.004 ns | 4.681 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,236.26 ns | 5.144 ns | 4.560 ns |  1.08 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   421.71 ns | 2.339 ns | 1.953 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   590.06 ns | 4.201 ns | 3.724 ns |  1.40 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |    33.85 ns | 0.233 ns | 0.207 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |    35.96 ns | 0.223 ns | 0.208 ns |  1.06 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |    34.49 ns | 0.228 ns | 0.213 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |    37.17 ns | 0.209 ns | 0.185 ns |  1.08 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,993.84 ns | 5.840 ns | 4.877 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,100.87 ns | 7.623 ns | 7.131 ns |  1.05 |    0.01 | 0.0305 |     - |     - |      64 B |
