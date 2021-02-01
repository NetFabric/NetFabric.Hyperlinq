## SelectManyBenchmarks

### Source
[SelectManyBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectManyBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                         Method |                Categories | Count |      Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |----------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |  3.416 μs | 0.0082 μs | 0.0073 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.270 μs | 0.0012 μs | 0.0010 μs |  0.37 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.361 μs | 0.0021 μs | 0.0019 μs |  0.40 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  3.631 μs | 0.0080 μs | 0.0067 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.505 μs | 0.0063 μs | 0.0053 μs |  0.97 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.730 μs | 0.0086 μs | 0.0080 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.454 μs | 0.0116 μs | 0.0103 μs |  0.93 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.725 μs | 0.0064 μs | 0.0054 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  1.331 μs | 0.0021 μs | 0.0016 μs |  0.36 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 13.882 μs | 0.0308 μs | 0.0273 μs |  1.00 | 2.3804 |     - |     - |    4984 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.428 μs | 0.0070 μs | 0.0062 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  1.497 μs | 0.0029 μs | 0.0026 μs |  0.44 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.426 μs | 0.0069 μs | 0.0058 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  1.487 μs | 0.0019 μs | 0.0017 μs |  0.43 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.430 μs | 0.0068 μs | 0.0061 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  1.327 μs | 0.0017 μs | 0.0016 μs |  0.39 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 13.511 μs | 0.0257 μs | 0.0215 μs |  1.00 | 2.3804 |     - |     - |    4984 B |
