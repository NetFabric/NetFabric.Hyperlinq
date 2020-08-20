## ContainsComparerBenchmarks

### Source
[ContainsComparerBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsComparerBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   609.9 ns |  4.00 ns |  3.74 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_Array |                     Array |   100 |   247.2 ns |  1.69 ns |  1.58 ns |  0.41 |      - |     - |     - |         - |
|                 Hyperlinq_Span |                     Array |   100 |   222.9 ns |  0.98 ns |  0.82 ns |  0.37 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |   223.7 ns |  0.66 ns |  0.55 ns |  0.37 |      - |     - |     - |         - |
|                                |                           |       |            |          |          |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   821.9 ns |  6.91 ns |  6.47 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   310.8 ns |  2.54 ns |  2.37 ns |  0.38 |      - |     - |     - |         - |
|                                |                           |       |            |          |          |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   823.0 ns |  6.47 ns |  5.40 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   228.9 ns |  1.47 ns |  1.37 ns |  0.28 |      - |     - |     - |         - |
|                                |                           |       |            |          |          |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   821.4 ns |  7.38 ns |  6.16 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   394.7 ns |  2.28 ns |  2.02 ns |  0.48 |      - |     - |     - |         - |
|                                |                           |       |            |          |          |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,195.0 ns | 14.18 ns | 13.26 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   601.0 ns |  2.61 ns |  2.18 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.0 ns |  4.24 ns |  3.54 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   604.0 ns |  3.28 ns |  3.07 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   582.4 ns |  2.72 ns |  2.27 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   601.3 ns |  3.18 ns |  2.82 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   394.9 ns |  2.16 ns |  1.91 ns |  0.66 |      - |     - |     - |         - |
|                                |                           |       |            |          |          |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,058.3 ns |  5.71 ns |  5.06 ns |  1.00 | 0.0191 |     - |     - |      40 B |
