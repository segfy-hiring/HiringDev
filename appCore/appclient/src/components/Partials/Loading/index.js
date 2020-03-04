import React from 'react'
import {LoadingWrap} from './styled'
import imgLoading from './loading.svg'

const Loading = (props) => {
    return (
        <LoadingWrap>
            {props.icon && <img src={imgLoading} alt="Carregando..." />}
            {props.label}
        </LoadingWrap>
    )
}

export default Loading