pipeline {
    agent any

    environment {
        DOCKERHUB_CREDENTIALS = 'dockerhub-creds'   // Jenkins credentials ID
        DOCKERHUB_USERNAME = 'harshavar28'
        BACKEND_IMAGE = 'harshavar28/prj5-backend'
        FRONTEND_IMAGE = 'harshavar28/prj5-frontnend'  // fixed typo here
    }

    stages {

        stage('Checkout') {
            steps {
                checkout scm
            }
        }

        stage('Build Docker Images') {
            steps {
                script {
                    // You can use GIT_COMMIT or BUILD_NUMBER for tagging
                    def tag = env.GIT_COMMIT ?: 'latest'

                    // Build backend image
                    docker.build("${BACKEND_IMAGE}:${tag}", "-f BMSB/Dockerfile .")

                    // Build frontend image
                    docker.build("${FRONTEND_IMAGE}:${tag}", "-f BMSF/Dockerfile .")
                }
            }
        }

        stage('Login to Docker Hub') {
            steps {
                script {
                    docker.withRegistry('https://registry.hub.docker.com', DOCKERHUB_CREDENTIALS) {
                        echo "Logged into Docker Hub"
                    }
                }
            }
        }

        stage('Push Images') {
            steps {
                script {
                    def tag = env.GIT_COMMIT ?: 'latest'
                    docker.image("${BACKEND_IMAGE}:${tag}").push()
                    docker.image("${FRONTEND_IMAGE}:${tag}").push()
                }
            }
        }

    }

    post {
        always {
            echo 'Cleaning up...'
            sh 'docker image prune -f'
        }
        success {
            echo 'Build and push succeeded!'
        }
        failure {
            echo 'Build failed. Check logs.'
        }
    }
}
