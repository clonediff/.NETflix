import { useEffect, useState } from "react";
import "./ExpandableBlock.css"
import AngleDown from "../../assets/angle-down-solid.svg"
import AngleUp from "../../assets/angle-up-solid.svg"

export const ExpandableBlock = ({ children, className, length = 10 }) => {
    const [expanded, setExpanded] = useState(false);
    const [childrenToShow, setChildrenToShow] = useState(children);
    const childrenSlice = children.slice(0, length);

    useEffect(() => {
        if (expanded)
            setChildrenToShow(children)
        else
            setChildrenToShow(childrenSlice)
    }, [expanded])

    return (
        <>
            <div className={className ? className : null}>
                {childrenToShow}
            </div>
            {
                children.length > length &&
                <a className="pointer dashed-underline" style={{color: 'white'}} onClick={() => setExpanded(x => !x)}>
                    <img src={expanded ? AngleUp : AngleDown} width={12} height={12}/>
                    {expanded ? 'Свернуть' : 'Показать больше'}
                </a>
            }
        </>
    );
  };