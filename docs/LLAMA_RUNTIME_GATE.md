# Joni llama.cpp Runtime Gate

Gate version: `0.2.1`

This gate installs the official `ggml-org/llama.cpp` Windows x64 CUDA runtime without downloading an AI model.

## Pinned upstream

- stable source release: `v0.3.0`
- binary build: `b10621`
- commit: `c1d0e7a004015f23bc0233470b747b596f29b264`
- primary backend: CUDA 13.3

## Acceptance chain

1. Verify the Joni runtime manifest with the embedded RSA-3072 development public key before parsing.
2. Enforce anti-rollback sequence `3 -> 4`.
3. Select the NVIDIA/CUDA hardware profile.
4. Download the official GitHub Release assets with resume support.
5. Verify exact sizes and upstream SHA-256 digests.
6. Extract into staging.
7. Require `llama-cli.exe` and `llama-server.exe`.
8. Run `llama-cli.exe --version`.
9. Run `llama-cli.exe --list-devices` and require CUDA plus `NVIDIA GeForce RTX 5080`.
10. Promote the staged runtime only after checks pass.
11. Perform a critical-executable rollback drill and re-run the device health check.
12. Commit sequence 4 only after the whole gate passes.

No model is downloaded in this gate, and no paid service is required.
