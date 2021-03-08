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
|                     Linq_Array |                     Array |   100 |  3.897 μs | 0.0145 μs | 0.0129 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.270 μs | 0.0045 μs | 0.0042 μs |  0.33 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.423 μs | 0.0021 μs | 0.0019 μs |  0.37 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  4.005 μs | 0.0287 μs | 0.0255 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.659 μs | 0.0341 μs | 0.0285 μs |  0.91 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.991 μs | 0.0116 μs | 0.0097 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.579 μs | 0.0187 μs | 0.0156 μs |  0.90 | 2.3575 |     - |     - |    4936 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  4.291 μs | 0.0328 μs | 0.0274 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.748 μs | 0.0151 μs | 0.0141 μs |  0.87 | 2.3499 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 14.461 μs | 0.0428 μs | 0.0400 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  4.049 μs | 0.0137 μs | 0.0114 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.421 μs | 0.0238 μs | 0.0211 μs |  0.84 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.788 μs | 0.0119 μs | 0.0099 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.391 μs | 0.0169 μs | 0.0141 μs |  0.90 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  4.164 μs | 0.0364 μs | 0.0323 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.839 μs | 0.0163 μs | 0.0152 μs |  0.92 | 2.3499 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 14.241 μs | 0.0649 μs | 0.0607 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
