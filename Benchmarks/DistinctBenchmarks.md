## DistinctBenchmarks

### Source
[DistinctBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/DistinctBenchmarks.cs)

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
|                              Method |                Categories | Count |     Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |---------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 3.176 μs | 0.0177 μs | 0.0166 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|                    StructLinq_Array |                     Array |   100 | 1.366 μs | 0.0085 μs | 0.0071 μs |  0.43 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 | 1.612 μs | 0.0057 μs | 0.0050 μs |  0.51 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 | 1.606 μs | 0.0082 μs | 0.0068 μs |  0.51 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 | 1.647 μs | 0.0063 μs | 0.0056 μs |  0.52 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 3.543 μs | 0.0184 μs | 0.0172 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 2.328 μs | 0.0110 μs | 0.0098 μs |  0.66 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 | 1.596 μs | 0.0053 μs | 0.0049 μs |  0.45 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 3.536 μs | 0.0196 μs | 0.0163 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 2.278 μs | 0.0150 μs | 0.0133 μs |  0.64 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 | 1.617 μs | 0.0084 μs | 0.0074 μs |  0.46 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 3.551 μs | 0.0217 μs | 0.0192 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|               StructLinq_List_Value |                List_Value |   100 | 1.632 μs | 0.0066 μs | 0.0059 μs |  0.46 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 | 1.986 μs | 0.0085 μs | 0.0079 μs |  0.56 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8.405 μs | 0.0278 μs | 0.0246 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5.037 μs | 0.0137 μs | 0.0114 μs |  0.60 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 | 3.170 μs | 0.0325 μs | 0.0304 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 | 1.824 μs | 0.0082 μs | 0.0077 μs |  0.58 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 | 2.069 μs | 0.0190 μs | 0.0169 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 | 3.163 μs | 0.0174 μs | 0.0163 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 | 1.817 μs | 0.0053 μs | 0.0047 μs |  0.57 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 | 2.067 μs | 0.0222 μs | 0.0208 μs |  0.65 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 | 3.139 μs | 0.0155 μs | 0.0138 μs |  1.00 | 2.0599 |     - |     - |    4312 B |
|           StructLinq_List_Reference |            List_Reference |   100 | 1.877 μs | 0.0085 μs | 0.0075 μs |  0.60 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 | 1.946 μs | 0.0127 μs | 0.0119 μs |  0.62 |      - |     - |     - |         - |
|                                     |                           |       |          |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8.223 μs | 0.0534 μs | 0.0499 μs |  1.00 | 2.0599 |     - |     - |    4328 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5.292 μs | 0.0188 μs | 0.0167 μs |  0.64 | 0.0153 |     - |     - |      40 B |
