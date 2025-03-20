#!/bin/bash

export REBUILD_STAGE_2=$(date +%s)
docker --context desktop-linux compose up --build -d
