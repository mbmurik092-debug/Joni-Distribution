# Joni Distribution

Public distribution manifests and bootstrap artifacts for **Joni / Personal AI**.

This repository is intentionally separate from the application source code. Its purpose is to provide a free, public, tokenless HTTPS distribution point for bootstrap manifests, schemas, checksums and small test artifacts.

## Trust model

The current bootstrap phase validates manifest and component SHA-256 values. A later gate will add cryptographic manifest signatures with the public verification key embedded in Joni Launcher.

## Channels

- `stable` — only components that passed the required gates.
- `beta` — pre-release validation.
- `dev` — development only.

## Current gate

`Joni Bootstrap Launcher v0.1.7` — Remote Manifest Gate.

No LLM or executable runtime is distributed by this test manifest.
