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
|                     Linq_Array |                     Array |   100 |  3.568 μs | 0.0164 μs | 0.0154 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|                Hyperlinq_Array |                     Array |   100 |  1.232 μs | 0.0030 μs | 0.0026 μs |  0.35 |      - |     - |     - |         - |
|               Hyperlinq_Memory |                     Array |   100 |  1.386 μs | 0.0038 μs | 0.0033 μs |  0.39 |      - |     - |     - |         - |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |  4.203 μs | 0.0233 μs | 0.0206 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  3.438 μs | 0.0189 μs | 0.0168 μs |  0.82 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |  3.864 μs | 0.0145 μs | 0.0136 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |  3.468 μs | 0.0240 μs | 0.0200 μs |  0.90 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |  3.883 μs | 0.0155 μs | 0.0130 μs |  1.00 | 1.9531 |     - |     - |    4096 B |
|           Hyperlinq_List_Value |                List_Value |   100 |  3.634 μs | 0.0291 μs | 0.0272 μs |  0.94 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 14.132 μs | 0.0951 μs | 0.0890 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.567 μs | 0.0189 μs | 0.0167 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  3.234 μs | 0.0210 μs | 0.0186 μs |  0.91 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |  3.600 μs | 0.0217 μs | 0.0181 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  3.213 μs | 0.0237 μs | 0.0222 μs |  0.89 | 2.3499 |     - |     - |    4920 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |  3.585 μs | 0.0239 μs | 0.0224 μs |  1.00 | 1.9569 |     - |     - |    4096 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |  3.777 μs | 0.0372 μs | 0.0330 μs |  1.05 | 2.3537 |     - |     - |    4928 B |
|                                |                           |       |           |           |           |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 14.888 μs | 0.0652 μs | 0.0578 μs |  1.00 | 2.3346 |     - |     - |    4912 B |
