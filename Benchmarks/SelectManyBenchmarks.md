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
|                         Method |                Categories | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  3.665 μs | 0.0180 μs | 0.0160 μs |  3.664 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.231 μs | 0.0030 μs | 0.0028 μs |  1.231 μs |  0.34 |    0.00 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.379 μs | 0.0018 μs | 0.0017 μs |  1.379 μs |  0.38 |    0.00 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  3.677 μs | 0.0182 μs | 0.0142 μs |  3.680 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.521 μs | 0.0674 μs | 0.1574 μs |  3.451 μs |  0.99 |    0.05 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.680 μs | 0.0139 μs | 0.0116 μs |  3.681 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.509 μs | 0.0690 μs | 0.1329 μs |  3.446 μs |  0.96 |    0.03 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  4.260 μs | 0.0201 μs | 0.0178 μs |  4.257 μs |  1.00 |    0.00 | 1.9531 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.653 μs | 0.0721 μs | 0.0963 μs |  3.612 μs |  0.86 |    0.02 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 13.749 μs | 0.0237 μs | 0.0198 μs | 13.752 μs |  1.00 |    0.00 | 2.3346 |     - |     - |    4912 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.409 μs | 0.0098 μs | 0.0087 μs |  3.408 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.260 μs | 0.0214 μs | 0.0190 μs |  3.251 μs |  0.96 |    0.01 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.430 μs | 0.0119 μs | 0.0111 μs |  3.429 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.170 μs | 0.0139 μs | 0.0130 μs |  3.167 μs |  0.92 |    0.00 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.419 μs | 0.0115 μs | 0.0107 μs |  3.417 μs |  1.00 |    0.00 | 1.9569 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.662 μs | 0.0143 μs | 0.0127 μs |  3.664 μs |  1.07 |    0.01 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 13.585 μs | 0.0364 μs | 0.0322 μs | 13.574 μs |  1.00 |    0.00 | 2.3346 |     - |     - |    4912 B |
