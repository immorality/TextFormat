import React from "react"

export default class Radio extends React.Component {

    constructor() {
        super();
    }

    click() {
        this.props.change(this.props.newValue)
    }

    render() {
        return (<div className="radio">
            <label>
                <input type="radio" value={this.props.newValue} onClick={this.props.click}/>
                {this.props.text}
            </label>
        </div>)
    }
}