<template>
    <div>
        <div class="page-eventos page-conteudo">
            <div class="banner-top">
                <div class="bg-top" :style="'margin: 0px; background: url(' + channel.thumbnail + ') no-repeat center;'">
                </div>
                <b-container>
                    <div class="img-banner">
                        <img v-bind:src="channel.thumbnail" alt="">
                    </div>
                </b-container>
            </div>


            <section class="text-center">
                <b-container>                    
                    <h3 class="title"><b>{{channel.name}}</b></h3>
                    <div class="details">
                      <b-col class="details-col">
                        <div class="description">

                            <div class="">
                                <p class="box-text"><b>Title:</b> {{channel.name}} </p>
                            </div>
                            <div class="">
                                <p class="box-text"><b>Date Created:</b> {{formatDate(channel.dateUploaded)}} </p>
                            </div>
                        </div>
                      </b-col>

                      <b-col class="details-col">
                        <div class="description mb-5">
                            <div class="mb-5">
                                <p class="box-text"> {{channel.description}} </p>                                
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

<style src="./Channel.scss" lang="scss"></style>
<script src="./Channel.js"></script>