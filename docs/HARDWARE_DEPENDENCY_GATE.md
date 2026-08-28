# Joni Hardware Profile + Dependency Resolver Gate

This gate extends the signed-manifest chain with hardware-aware profile selection and dependency resolution.

## Profiles

The signed resolver manifest currently provides three ordered profiles:

1. `windows-x64-nvidia-16gb-32ram` — priority 100; Windows x64, at least 24 GB RAM, NVIDIA GPU, at least 14,000 MB VRAM.
2. `windows-x64-nvidia-8gb` — priority 50; Windows x64, at least 16 GB RAM, NVIDIA GPU, at least 7,000 MB VRAM.
3. `windows-x64-cpu-fallback` — priority 10; Windows x64 and at least 8 GB RAM.

The highest-priority matching profile wins.

## Resolver rules

- component IDs must be unique;
- every root component must exist;
- every dependency must exist;
- cycles are blocked;
- dependencies are recursively expanded;
- installation order is topological: dependencies before dependents;
- only components reachable from the selected profile roots are installed;
- every artifact is still checked by SHA-256 and Health Check;
- the signed-manifest anti-rollback sequence advances from 1 to 2 only after the full selected plan passes.

## Expected RTX 5080 / 32 GB test result

Selected profile: `windows-x64-nvidia-16gb-32ram`.

Expected installation plan:

1. `runtime-base`
2. `brain-foundation` and `voice-foundation` after runtime-base
3. `profile-nvidia16` after brain-foundation and voice-foundation

No executable runtime or LLM is installed by this gate.
