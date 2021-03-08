## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   199.497 ns |  1.0047 ns |  0.8906 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.172 ns |  0.0210 ns |  0.0186 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.520 ns |  0.0386 ns |  0.0342 ns |  0.08 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    15.249 ns |  0.0578 ns |  0.0512 ns |  0.08 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    15.725 ns |  0.0512 ns |  0.0454 ns |  0.08 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   800.922 ns |  2.9386 ns |  2.6050 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   805.170 ns |  4.1277 ns |  3.6591 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   345.775 ns |  0.8853 ns |  0.7392 ns |  0.43 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   844.641 ns |  5.4113 ns |  4.5187 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   791.492 ns |  4.4285 ns |  3.6980 ns | 0.937 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     4.249 ns |  0.0437 ns |  0.0387 ns | 0.005 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   438.392 ns |  2.4073 ns |  2.0102 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.611 ns |  0.0326 ns |  0.0289 ns |  0.02 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     9.977 ns |  0.0227 ns |  0.0189 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,714.656 ns | 85.5076 ns | 71.4028 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,806.390 ns | 44.6512 ns | 41.7667 ns |  1.01 | 0.0610 |     - |     - |     152 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   559.117 ns |  5.6889 ns |  4.7505 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   580.771 ns |  2.9281 ns |  2.4451 ns |  1.04 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   262.379 ns |  1.1201 ns |  0.9929 ns |  0.47 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   556.965 ns |  2.3168 ns |  1.9346 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   585.834 ns |  7.9246 ns |  7.0250 ns | 1.051 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.224 ns |  0.0192 ns |  0.0171 ns | 0.008 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   439.290 ns |  1.9304 ns |  1.7112 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   578.988 ns |  2.4923 ns |  2.2094 ns |  1.32 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     9.626 ns |  0.0457 ns |  0.0405 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,752.487 ns | 42.6378 ns | 37.7973 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,330.738 ns | 32.9557 ns | 29.2144 ns |  1.07 | 0.0610 |     - |     - |     152 B |
