<template>
    <div>
        <div class="page-eventos page-conteudo">
            <div class="banner-top-video">
                <div class="bg-top" :style="'margin: 0px; background: url(' + video.thumb + ') no-repeat center;'">
                </div>
                <b-container>
                    <div class="img-banner">
                        <img v-bind:src="video.thumb" alt="">
                    </div>
                </b-container>
            </div>


            <section class="text-center">
                <b-container>                    
                    <h3 class="title"><b>{{video.name}}</b></h3>
                    <div class="details">
                      <b-col class="details-col">
                        <div class="description">

                            <div class="">
                                <p class="box-text"><b>Title:</b> {{video.name}} </p>
                            </div>
                            <div class="">
                                <p class="box-text"><b>Date Created:</b> {{formatDate(video.publishDate)}} </p>
                            </div>
                        </div>
                      </b-col>

                      <b-col class="details-col">
                        <div class="description mb-5">
                            <div class="mb-5">
                                <p class="box-text"> {{video.description}} </p>                                
                            </div>
                            <div class="justify-content-center d-flex">
                              <div class="bt-defaults ml-3 w-100">
                                <button type="button" class="ml-auto" @click="back()" variant="primary">Back</button>
                              </div>
                            </div>
                        </div>
                      </b-col>
                    
                    </div>
                </b-container>     
            </section>

        </div>
    </div>
</template>

<style src="./Video.scss" lang="scss"></style>
<script src="./Video.js"></script>