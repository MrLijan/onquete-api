docker-up: 
	docker-compose -f .docker/docker-compose.yml up --build --force-recreate -d -- 

docker-kill:
	docker kill $(docker ps -aq)