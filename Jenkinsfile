pipeline {
    agent any

    environment {
        DOCKERHUB_CREDENTIALS = credentials('dockerhub-creds')  // Set this in Jenkins
        DOCKERHUB_USER = 'harshavar28'
        FRONTEND_IMAGE = "${DOCKERHUB_USER}/prj5-frontend"
        BACKEND_IMAGE  = "${DOCKERHUB_USER}/prj5-backend"
    }

    stages {
        stage('Checkout Code') {
            steps {
                checkout scm
            }
        }

        stage('Build Frontend Image') {
            steps {
                script {
                    docker.build(FRONTEND_IMAGE, '-f BMSF/Dockerfile .')
                }
            }
        }

        stage('Build Backend Image') {
            steps {
                script {
                    docker.build(BACKEND_IMAGE, '-f BMSB/Dockerfile .')
                }
            }
        }

        stage('Docker Hub Login') {
            steps {
                script {
                    sh "echo ${DOCKERHUB_CREDENTIALS_PSW} | docker login -u ${DOCKERHUB_USER} --password-stdin"
                }
            }
        }

        stage('Push Images to Docker Hub') {
            steps {
                script {
                    docker.image(FRONTEND_IMAGE).push('latest')
                    docker.image(BACKEND_IMAGE).push('latest')
                }
            }
        }
    }

    post {
        always {
            sh 'docker logout'
        }
    }
}
