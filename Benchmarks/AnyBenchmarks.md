## AnyBenchmarks

### Source
[AnyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 10.053 ns | 0.1956 ns | 0.3214 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  7.570 ns | 0.0404 ns | 0.0358 ns |  0.74 |    0.03 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  6.777 ns | 0.1074 ns | 0.0952 ns |  0.66 |    0.03 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  9.484 ns | 0.0275 ns | 0.0244 ns |  0.92 |    0.04 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 21.413 ns | 0.0935 ns | 0.0828 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 10.994 ns | 0.0411 ns | 0.0365 ns |  0.51 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  4.882 ns | 0.0583 ns | 0.0487 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  8.468 ns | 0.0371 ns | 0.0347 ns |  1.73 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  5.707 ns | 0.0578 ns | 0.0541 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  1.611 ns | 0.0107 ns | 0.0100 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 68.422 ns | 0.3174 ns | 0.2814 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 65.771 ns | 0.3539 ns | 0.2955 ns |  0.96 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 18.487 ns | 0.1284 ns | 0.1003 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 10.908 ns | 0.1359 ns | 0.1271 ns |  0.59 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  4.885 ns | 0.0359 ns | 0.0318 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.897 ns | 0.0386 ns | 0.0323 ns |  0.39 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  5.705 ns | 0.0465 ns | 0.0363 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  1.627 ns | 0.0065 ns | 0.0058 ns |  0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 66.169 ns | 0.2316 ns | 0.2167 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 63.750 ns | 0.1345 ns | 0.1123 ns |  0.96 |    0.00 | 0.0191 |     - |     - |      40 B |
