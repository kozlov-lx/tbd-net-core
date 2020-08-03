#!/usr/bin/env bash

# postgres_data
mkdir -pv /var/app/tbd/postgres/data
chown 999:999 /var/app/tbd/postgres/data

# stack
docker stack deploy -c stack.yml tbd
