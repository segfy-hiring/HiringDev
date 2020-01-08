(function () {
    'use strict';

    angular.module('app.youtube')
    	.service('youtubeResource', youtubeResource);

    function youtubeResource(BaseResource) {
        let baseUrl = '/odata/YoutubeData';

        angular.extend(this, new BaseResource({ url: baseUrl }));

        function searchYoutube(keyword, type, pageToken) {
            var url = baseUrl + "/Search(keyword='" + keyword + "',type=" + type + ", pageToken='" + pageToken + "')";
            return this.get(url);
        }

        function getVideoDetail(videoId) {
            var url = baseUrl + "/GetVideoDetail(videoId='" + videoId + "')";
            return this.get(url);
        }

        function getChannelDetail(channelId) {
            var url = baseUrl + "/GetChannelDetail(channelId='" + channelId + "')";
            return this.get(url);
        }

        this.searchYoutube = searchYoutube;
        this.getVideoDetail = getVideoDetail;
        this.getChannelDetail = getChannelDetail;

        return this;
    }
})();
