docker-up:
	docker-compose -f .docker/docker-compose.database.yml up --build -d --

docker-kill:
	docker kill $(docker ps -aq) --