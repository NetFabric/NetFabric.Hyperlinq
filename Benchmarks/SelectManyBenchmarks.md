## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

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
|                         Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  3.485 μs | 0.0168 μs | 0.0149 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.352 μs | 0.0064 μs | 0.0060 μs |  0.39 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.447 μs | 0.0082 μs | 0.0077 μs |  0.42 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  4.061 μs | 0.0367 μs | 0.0325 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  1.389 μs | 0.0074 μs | 0.0070 μs |  0.34 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.829 μs | 0.0247 μs | 0.0219 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  1.396 μs | 0.0099 μs | 0.0093 μs |  0.36 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.782 μs | 0.0280 μs | 0.0262 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  1.396 μs | 0.0125 μs | 0.0117 μs |  0.37 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 14.200 μs | 0.0706 μs | 0.0626 μs |  1.00 | 2.3804 |     - |     - |    4984 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.786 μs | 0.0196 μs | 0.0163 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  1.614 μs | 0.0078 μs | 0.0069 μs |  0.43 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.604 μs | 0.0268 μs | 0.0238 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.617 μs | 0.0088 μs | 0.0082 μs |  0.45 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.595 μs | 0.0136 μs | 0.0120 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  1.410 μs | 0.0057 μs | 0.0053 μs |  0.39 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 13.991 μs | 0.0825 μs | 0.0772 μs |  1.00 | 2.3804 |     - |     - |    4984 B |
