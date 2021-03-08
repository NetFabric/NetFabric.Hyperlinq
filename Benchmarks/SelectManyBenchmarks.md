## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

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
|                         Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  3.556 μs | 0.0119 μs | 0.0111 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.226 μs | 0.0042 μs | 0.0035 μs |  0.34 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.381 μs | 0.0023 μs | 0.0021 μs |  0.39 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  3.817 μs | 0.0077 μs | 0.0065 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.439 μs | 0.0133 μs | 0.0111 μs |  0.90 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.821 μs | 0.0122 μs | 0.0114 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.360 μs | 0.0157 μs | 0.0140 μs |  0.88 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.754 μs | 0.0147 μs | 0.0130 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.530 μs | 0.0093 μs | 0.0078 μs |  0.94 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 13.831 μs | 0.0353 μs | 0.0313 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.596 μs | 0.0158 μs | 0.0148 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.201 μs | 0.0208 μs | 0.0185 μs |  0.89 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.545 μs | 0.0128 μs | 0.0113 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.193 μs | 0.0111 μs | 0.0098 μs |  0.90 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.528 μs | 0.0116 μs | 0.0103 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.620 μs | 0.0165 μs | 0.0146 μs |  1.03 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 13.608 μs | 0.0423 μs | 0.0375 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
